import React from "react";

const SortedOutput = ({ numbers, isLoading }) => {
  if (isLoading) {
    return (
      <div
        data-testid="is-loading"
        className="flex justify-center items-center"
      >
        <div className="animate-spin rounded-full h-8 w-8 border-b-2 border-gray-900"></div>
      </div>
    );
  }

  if ((!numbers || numbers.length === 0) && !isLoading) {
    return (
      <div className="mt-6">
        <div className="p-4 bg-green-50 border border-gray-200 rounded-lg shadow-sm">
          <p data-testid="no-numbers-message" className="text-gray-500">
            No numbers to display.
          </p>
        </div>
      </div>
    );
  }

  return (
    <div className="mt-6">
      <h2 className="text-xl font-semibold mb-2">
        Sorted Numbers (Highest to Lowest):
      </h2>
      <div
        className="p-4 bg-green-50 border border-gray-200 rounded-lg shadow-sm"
        data-testid="sorted-numbers"
      >
        <p className="text-lg font-mono text-gray-700">{numbers.join(", ")}</p>
      </div>
    </div>
  );
};

export default SortedOutput;
