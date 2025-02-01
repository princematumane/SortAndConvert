import React, { useState } from "react";

const NumberInput = ({ onSubmit, onError }) => {
  const [inputValue, setInputValue] = useState("");
  const [isValid, setIsValid] = useState(true);

  const handleInputChange = (e) => {
    const value = e.target.value;
    setInputValue(value);
    setIsValid(/^[\d,]*$/.test(value));
  };

  const handleSubmit = () => {
    const trimmedInput = inputValue.replace(/\s+/g, "").trim();

    if (trimmedInput == "") {
      return;
    }
    console.log(trimmedInput);

    if (!/^[\d,]+$/.test(trimmedInput)) {
      onError("Input should only contain numbers and commas.");
      setIsValid(false);
      return;
    }

    const numbers = trimmedInput.split(",").map((num) => Number(num.trim()));

    onSubmit(numbers);
    setIsValid(true);
  };

  const handleClear = () => {
    setInputValue("");
    setIsValid(true);
    onError("");
  };

  return (
    <div className="space-y-4">
      <input
        type="text"
        value={inputValue}
        onChange={handleInputChange}
        placeholder="Enter comma-separated numbers"
        className={`w-full p-2 border ${
          isValid ? "border-gray-300" : "border-red-500"
        } rounded focus:outline-none focus:ring-2 ${
          isValid ? "focus:ring-blue-500" : "focus:ring-red-500"
        }`}
        data-testid="number-input"
      />
      <div className="flex space-x-2">
        <button
          onClick={handleSubmit}
          className="px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
          data-testid="sort-button"
        >
          Sort
        </button>
        <button
          onClick={handleClear}
          className="px-4 py-2 bg-gray-500 text-white rounded hover:bg-gray-600 focus:outline-none focus:ring-2 focus:ring-gray-500"
          data-testid="clear-button"
        >
          Clear
        </button>
      </div>
    </div>
  );
};

export default NumberInput;
