# Research

## `IReadOnlyDictionary<TKey, TValue>`

- It is an interface, not a collection. It's a read-only view of key and value pairs that can be enumerated and looked up. It has no ordering.

- It has no add or remove, so the type itself blocks mutation. That is why a public method should return it rather than a `Dictionary`. The backing field should also be `readonly` to prevent reassignment.

- Important thing: if the caller casts it back to `Dictionary`, they can mutate it again. A wrapper like `ReadOnlyDictionary` only hides the original, which can still change behind the wrapper. It is a view, not a snapshot.

## `SortedDictionary` vs `Dictionary`

- `Dictionary` is fast but has no order, while `SortedDictionary` keeps its keys sorted automatically.

- `SortedDictionary` is implemented as a red-black tree, a self-balancing binary search tree.

- Search speed: `Dictionary` is close to `O(1)`, `SortedDictionary` is `O(log n)`.

- Insert and remove both take `O(log n)` in `SortedDictionary`, while `Dictionary` is close to `O(1)` for them.

- use `SortedDictionary` only when we need sorted iteration or sorted lookups. Otherwise `Dictionary` is simpler and faster.

## Sources

- Microsoft Learn, `IReadOnlyDictionary<TKey,TValue>` interface:
  https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2
- Microsoft Learn, `ReadOnlyDictionary<TKey,TValue>` class:
  https://learn.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.readonlydictionary-2
- Microsoft Learn, `SortedDictionary<TKey,TValue>` class:
  https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2

# Pick the Collection

## S1: Find a student by national ID, thousands of times a day

**`Dictionary`**: the national ID is the key and the student is the value, and a `Dictionary` finds a key in close to O(1) time, which is the fastest option for this many lookups.

## S2: Keep the tags of a course. The same tag must never be stored twice

**`HashSet`**: a set holds only unique items, so adding a tag that already exists is ignored and duplicates can never be stored.

## S3: Keep a student's grades in the order they were entered. The same grade can appear more than once

**`List`**: it keeps items in the order they were added and allows duplicates.

## S4: A public method returns the course price list. Callers can read prices but must not add or change any

**`IReadOnlyDictionary`**: callers can look up prices by course but the interface has no add or remove, so the type itself blocks changes.

## S5: A timetable keyed by session start time. Sessions are added at any moment, and it must always print in time order

**`SortedDictionary`**: it keeps keys sorted automatically, so sessions inserted at any moment always print in start-time order without a separate sort.

## S6: A method returns results that the caller only loops over once, and may stop early

**`IEnumerable`**: it only supports looping forward, and with `yield return` the items are produced one at a time, so stopping early skips the remaining work.