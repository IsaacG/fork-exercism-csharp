# Hints

## General

## 1. Buy a brand-new remote controlled car

- [This page shows how to create a new instance of a class][creating-objects].

## 2. Display the distance driven

- Keep track of the distance driven in a [field][fields].
- Consider what visibility to use for the field (does it need to be used outside the class?).
- Consider using [string interpolation][string-interpolation] to format the string to return.

## 3. Display the battery percentage

- Keep track of the initial battery charge in a [field][fields].
- Initialize the field to a specific value that corresponds to the expected initial battery charge.
- Consider what visibility to use for the field (does it need to be used outside the class?).
- Consider using [string interpolation][string-interpolation] to format the string to return.

## 4. Update the number of meters driven when driving

- Update the field representing the distance driven.

## 5. Update the battery percentage when driving

- Update the field representing the battery percentage driven.

## 6. Prevent driving when the battery is drained

- Add a conditional to only update the distance and battery if the battery is not already drained.
- Add a conditional to display the empty battery message if the battery is drained.

[creating-objects]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/classes#creating-objects
[fields]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/fields
[string-interpolation]: https://christianfindlay.com/2019/10/04/c-string-interpolation/
