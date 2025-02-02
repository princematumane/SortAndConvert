# ReactJS + Vite Application & C# Command Line Application

This repository contains two separate projects:

1. A ReactJS application built with Vite that takes a list of comma-separated numbers, validates the input, and displays the numbers sorted from highest to lowest. It also ensures that only numbers and commas are accepted as input.
2. A C# Command Line application that accepts a Reverse Polish Notation (RPN) string and converts it into Infix Notation using a version of the Shunting Yard Algorithm.
   - (1) Take a stack
   - (2) When we see a number, we push it to stack
   - (3) When we see a operator, we pop two numbers out of stack and calculate them with help of operator and push the result into stack again
   - (4) We do it till the end
   - (5) At last, only a number would be left in stack, that is our answer.

## Table of Contents

- [ReactJS + Vite Application](#reactjs--vite-application)
  - [Installation](#installation)
  - [Usage](#usage)
  - [Example](#example)
- [C# Command Line Application](#c-command-line-application)
  - [Installation](#installation-1)
  - [Usage](#usage-1)
  - [Example](#example-1)

---

## ReactJS + Vite Application

### Installation

To get the ReactJS application up and running, follow these steps:

1. Clone the repository:

   ```bash
   git clone https://github.com/princematumane/SortAndConvert.git
   cd SortAndConvert
   ```

2. Install the required dependencies:

   ```bash
   npm install
   ```

3. Start the development server:
   ```bash
   npm run start
   ```

The app will be available at `http://localhost:5173/`.

### Usage

This ReactJS app accepts a list of comma-separated numbers and outputs the numbers sorted from highest to lowest. The input is validated to ensure it only contains numbers and commas.

- Enter your numbers in the input field.
- If the input is valid, the numbers will be displayed sorted in descending order.
- If the input is invalid, an error message will be shown, indicating that only numbers are allowed.

### Example

#### Input:

```
1,3,5,2,4,7,6
```

#### Output:

```
7,6,5,4,3,2,1
```

#### Input:

```
1,2,3,A,4,5,6
```

#### Output:

```
Error: Input should only contain numbers.
```

---

## C# Command Line Application

### Installation

To get the C# Command Line application up and running, follow these steps:

1. Clone the repository:

   ```bash
   git clone https://github.com/princematumane/SortAndConvert.git
   cd SortAndConvert
   ```

2. Open the project in Visual Studio or any C# IDE.

3. Build and run the application.

### Usage

This application takes a Reverse Polish Notation (RPN) expression as input and outputs the equivalent Infix Notation expression.

#### Example

Input:

```
3 4 × 5 6 × +
```

Output:

```
(3 × 4) + (5 × 6)
```

Input:

```
12 + 34 + × 1 2 + 3 4 + ×
```

Output:

```
(1 + 2) × (3 + 4) × (1 + 2) × (3 + 4)
```

---

### License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
