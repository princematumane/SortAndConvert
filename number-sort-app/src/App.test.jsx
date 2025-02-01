import React from "react";
import "@testing-library/jest-dom";
import { render, screen, fireEvent, waitFor } from "@testing-library/react";
import App from "./App";

describe("Number Sorter App", () => {
  test("renders the app title", () => {
    render(<App />);
    const titleElement = screen.getByText(/Number Sorter/i);
    expect(titleElement).toBeInTheDocument();
  });

  test("sorts numbers correctly after 1000ms delay", async () => {
    render(<App />);
    const input = screen.getByTestId("number-input");
    const button = screen.getByTestId("sort-button");

    fireEvent.change(input, { target: { value: "1,3,5,2,4,7,6" } });
    fireEvent.click(button);

    await waitFor(() => {
      expect(screen.getByTestId("sorted-numbers")).toHaveTextContent(
        "7, 6, 5, 4, 3, 2, 1"
      );
    });
  });

  test("sorts numbers correctly after 1000ms delay even when some have have spaces", async () => {
    render(<App />);
    const input = screen.getByTestId("number-input");
    const button = screen.getByTestId("sort-button");

    fireEvent.change(input, { target: { value: "1,3, 5, 2,4, 7,6" } });
    fireEvent.click(button);

    await waitFor(() => {
      expect(screen.getByTestId("sorted-numbers")).toHaveTextContent(
        "7, 6, 5, 4, 3, 2, 1"
      );
    });
  });

  test("displays loading state while sorting, then shows sorted numbers", async () => {
    render(<App />);
    const input = screen.getByTestId("number-input");
    const button = screen.getByTestId("sort-button");

    fireEvent.change(input, { target: { value: "1,3,5,2,4,7,6" } });
    fireEvent.click(button);

    expect(screen.getByTestId("is-loading")).toBeInTheDocument();

    await waitFor(() => {
      expect(screen.queryByTestId("is-loading")).not.toBeInTheDocument();
    });

    const outputSection = await screen.findByTestId("sorted-numbers");
    expect(outputSection).toHaveTextContent("7, 6, 5, 4, 3, 2, 1");
  });

  test("displays error for invalid input", async () => {
    render(<App />);
    const input = screen.getByTestId("number-input");
    const button = screen.getByTestId("sort-button");

    fireEvent.change(input, { target: { value: "1,2,3,A,4,5,6" } });
    fireEvent.click(button);

    const errorMessage = screen.getByTestId("error-message");
    expect(errorMessage).toBeInTheDocument();
    expect(errorMessage).toHaveTextContent(
      "Input should only contain numbers and commas."
    );
  });

  test("clears input and error message", () => {
    render(<App />);
    const input = screen.getByTestId("number-input");
    const sortButton = screen.getByTestId("sort-button");
    const clearButton = screen.getByTestId("clear-button");

    fireEvent.change(input, { target: { value: "1,2,3,A,4,5,6" } });
    fireEvent.click(sortButton);

    fireEvent.click(clearButton);

    expect(input).toHaveValue("");
    expect(
      screen.queryByText("Input should only contain numbers and commas.")
    ).not.toBeInTheDocument();
  });

  test("displays 'No numbers to display' when there are no numbers and not loading", async () => {
    render(<App />);
    const input = screen.getByTestId("number-input");
    const button = screen.getByTestId("sort-button");

    fireEvent.change(input, { target: { value: "" } });
    fireEvent.click(button);

    await waitFor(() => {
      expect(screen.queryByTestId("is-loading")).not.toBeInTheDocument();
    });

    const noNumbersMessage = screen.getByTestId("no-numbers-message");
    expect(noNumbersMessage).toHaveTextContent("No numbers to display.");
  });
});
