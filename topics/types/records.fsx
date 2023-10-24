type Author = {
    AuthorID: int;
    FirstName: string;
    LastName: string;
    Biography: string option;
}

type Book = {
    BookID: int;
    Title: string;
    ISBN: string;
    PublishedDate: System.DateTime;
    Price: float;
    StockCount: int;
    Author: Author;
}

type Customer = {
    CustomerID: int;
    FirstName: string;
    LastName: string;
    Email: string;
    Address: string;
    PhoneNumber: string;
}
type Order = {
    OrderID: int;
    OrderDate: System.DateTime;
    Customer: Customer;
    TotalAmount: float;
    OrderItems: OrderItem list;
}

and OrderItem = {
    OrderItemID: int;
    Book: Book;
    Quantity: int;
    Subtotal: float;
}
