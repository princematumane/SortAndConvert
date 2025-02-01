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

  test("sorts numbers correctly", async () => {
    render(<App />);
    const input = screen.getByTestId("number-input");
    const button = screen.getByTestId("sort-button");

    fireEvent.change(input, { target: { value: "1,3,5,2,4,7,6" } });
    fireEvent.click(button);

    const sortedNumbers = await screen.findByText(/7, 6, 5, 4, 3, 2, 1/);
    expect(sortedNumbers).toBeInTheDocument();
  });

  test("displays error for invalid input", async () => {
    render(<App />);
    const input = screen.getByTestId("number-input");
    const button = screen.getByTestId("sort-button");

    fireEvent.change(input, { target: { value: "1,2,3,A,4,5,6" } });
    fireEvent.click(button);

    const errorMessage = await screen.findByText(
      "Input should only contain numbers and commas."
    );
    expect(errorMessage).toBeInTheDocument();
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

  test("displays loading state while sorting", () => {
    render(<App />);
    const input = screen.getByTestId("number-input");
    const button = screen.getByTestId("sort-button");

    fireEvent.change(input, { target: { value: "10,3,5" } });
    fireEvent.click(button);

    const loadingText = screen.getByTestId("is-loading");
    expect(loadingText).toBeInTheDocument();
  });

  test("displays 'No numbers to display' when there are no numbers and not loading", () => {
    render(<App />);
    const input = screen.getByTestId("number-input");
    const button = screen.getByTestId("sort-button");

    fireEvent.change(input, { target: { value: "" } });
    fireEvent.click(button);

    const noNumbersMessage = screen.getByTestId("no-numbers-message");
    expect(noNumbersMessage).toHaveTextContent("No numbers to display.");
  });

  test("handles empty input gracefully", async () => {
    render(<App />);
    const input = screen.getByTestId("number-input");
    const button = screen.getByTestId("sort-button");

    fireEvent.change(input, { target: { value: "" } });
    fireEvent.click(button);

    const errorMessage = await screen.findByText(
      "Input should only contain numbers and commas."
    );
    expect(errorMessage).toBeInTheDocument();
  });
});
