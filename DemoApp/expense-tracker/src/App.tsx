import React, { useState } from 'react';
import ExpenseItem from './components/ExpenseItem';
import './styles/App.css';

const App = () => {
    const [expenses, setExpenses] = useState([
        { id: 1, title: 'Groceries', amount: 50, date: '2023-10-01' },
        { id: 2, title: 'Utilities', amount: 100, date: '2023-10-05' },
    ]);

    const addExpense = (title, amount, date) => {
        const newExpense = {
            id: expenses.length + 1,
            title,
            amount,
            date,
        };
        setExpenses([...expenses, newExpense]);
    };

    const removeExpense = (id) => {
        setExpenses(expenses.filter(expense => expense.id !== id));
    };

    return (
        <div className="App">
            <h1>Expense Tracker</h1>
            <div>
                {expenses.map(expense => (
                    <ExpenseItem 
                        key={expense.id} 
                        title={expense.title} 
                        amount={expense.amount} 
                        date={expense.date} 
                        onRemove={() => removeExpense(expense.id)} 
                    />
                ))}
            </div>
            {/* Add functionality to add expenses here */}
        </div>
    );
};

export default App;