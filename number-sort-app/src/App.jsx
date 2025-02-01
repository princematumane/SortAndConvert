import React, { useState } from "react";
import NumberInput from "./components/NumberInput";
import SortedOutput from "./components/SortedOutput";

const App = () => {
  const [sortedNumbers, setSortedNumbers] = useState([]);
  const [error, setError] = useState("");
  const [isLoading, setIsLoading] = useState(false);

  const handleSubmit = (numbers) => {
    setIsLoading(true);
    setTimeout(() => {
      const sorted = numbers.sort((a, b) => b - a);
      setSortedNumbers(sorted);
      setError("");
      setIsLoading(false);
    }, 1000);
  };

  const handleError = (errorMessage) => {
    setError(errorMessage);
    setSortedNumbers([]);
  };

  return (
    <div className="min-h-screen bg-gray-100 flex flex-col items-center justify-center p-4">
      <div className="bg-white p-6 rounded-lg shadow-lg w-full max-w-md">
        <h1 className="text-2xl font-bold mb-4 text-center">Number Sorter</h1>
        <NumberInput onSubmit={handleSubmit} onError={handleError} />
        {error && <div className="text-red-500 mt-2">{error}</div>}
        <SortedOutput numbers={sortedNumbers} isLoading={isLoading} />
      </div>
    </div>
  );
};

export default App;
