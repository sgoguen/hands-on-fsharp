
type Shape =
    | Circle of radius: float
    | Rectangle of width: float * height: float
    | Triangle of baseL: float * height: float

type TrafficLight =
    | Red
    | Yellow
    | Green

type Option<'a> =
    | Some of 'a
    | None

type Result<'T, 'E> =
    | Ok of 'T
    | Error of 'E

type BinaryTree<'a> =
    | Leaf
    | Node of value: 'a * left: BinaryTree<'a> * right: BinaryTree<'a>

type Day =
    | Monday
    | Tuesday
    | Wednesday
    | Thursday
    | Friday
    | Saturday
    | Sunday

type UserRole =
    | Admin
    | User
    | Guest

type Expr =
    | Int of int
    | Add of Expr * Expr
    | Subtract of Expr * Expr
    | Multiply of Expr * Expr

type PaymentMethod =
    | Cash
    | CreditCard of number: string
    | PayPal of email: string

type FileSystemItem =
    | File of name: string
    | Directory of name: string * items: FileSystemItem list

type Contact =
    | Email of address: string
    | Phone of number: string

type Event =
    | Click
    | Scroll of distance: int
    | KeyPress of char

type Color =
    | RGB of r: int * g: int * b: int
    | Hex of string

type Product =
    | Book of title: string
    | Electronics of brand: string
    | Clothing of size: string

type Transport =
    | Car of make: string
    | Bicycle of brand: string
    | Bus of route: int

type Command =
    | Move of direction: string
    | Stop
    | Jump of height: int


type UserStatus =
    | Active
    | Inactive
    | Banned of reason: string

type Point =
    | TwoD of x: float * y: float
    | ThreeD of x: float * y: float * z: float

type Temperature =
    | Celsius of float
    | Fahrenheit of float
    | Kelvin of float
