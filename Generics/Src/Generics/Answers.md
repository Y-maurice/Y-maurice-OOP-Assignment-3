## Step 2: What is the same between the two stores, and what is different?

### Same
- Both stores have the same four methods: `Add`, `GetById`, `GetAll`, and `Remove`.
- Both keep their items in a private `List<...>`.
- The logic is identical: `GetById` loops through the list, compares `Id`, and returns the item or `null`. `Remove` calls `GetById` and removes the item if it was found. `GetAll` returns a read-only view of the list.
- The only property of the item that the store code uses is `Id`. It never touches `Name`, `Title`, or `Price`.

### Different
- Only the type is different. `StudentStore` works with `Student`, and `CourseStore` works with `Course`. That changes the type of the list, the parameter of `Add`, and the return types of `GetById` and `GetAll`.
- The two item classes have different properties (`Name` vs `Title` and `Price`), but the stores don't depend on that.
