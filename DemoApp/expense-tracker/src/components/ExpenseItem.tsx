const ExpenseItem: React.FC<{ title: string; amount: number; date: string }> = ({ title, amount, date }) => {
    return (
        <div className="expense-item">
            <div className="expense-item__description">
                <h2>{title}</h2>
                <div className="expense-item__price">${amount.toFixed(2)}</div>
            </div>
            <div className="expense-item__date">{new Date(date).toLocaleDateString()}</div>
        </div>
    );
};

export default ExpenseItem;