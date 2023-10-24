### F# Units of Measure: Overview

- **Purpose**: Enhance data type safety by attaching units to numbers.
- **Benefit**: Prevents common mistakes, e.g., adding meters to feet without conversion.
- **Built on**: F# generic types but with special syntax and behavior.
- **Scope**: Primarily for floating-point (`float`) values, but can be used with others.
- **Interoperability**: Stripped away during compilation; no runtime overhead.

### Examples

1. **Defining Units of Measure**:
    ```fsharp
    [<Measure>] type m
    [<Measure>] type ft
    ```

2. **Using Units of Measure**:
    ```fsharp
    let distance1 = 100.0<m>
    let distance2 = 300.0<ft>
    ```

3. **Arithmetic with Units**:
    ```fsharp
    // This will cause a compile-time error (different units)
    // let sum = distance1 + distance2

    let conversionFactor = 0.3048  // 1 foot is 0.3048 meters
    let distance2InMeters = distance2 * conversionFactor
    let sum = distance1 + distance2InMeters
    ```

4. **Derived Units**:
    ```fsharp
    [<Measure>] type s  // second
    let speed = 30.0<m/s>
    ```

### Key Takeaways

- F# Units of Measure provide type safety for numerical values.
- They help catch unit-related errors at compile-time.
- They're erased at runtime, ensuring no performance cost.