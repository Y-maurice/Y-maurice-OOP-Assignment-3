# Part 03 — answers

---

## BlockedUsers

- Time complexity before: 

O(n × m), List.Contains scans the list for every request id

- Time (ms) before: 31
- What did you change?

Copy the blocked ids into a HashSet<int> once, then check each request id with it's
O(1) contains instead of scanning the list

- Time complexity after:

O(n+m) , O(n) to build the set and o(m) for the lookups

- Time (ms) after: 1 (most of it is building the set; the lookups themselves are almost free)

---

## Students

- What was the problem?

GetAllStudents built all 1,000,000 students in a list before returning, so that work was done even though only 3 were used.

- What did you change?

Made it an iterator with yield return so students are created one at a time on demand and breaking after 3 stops the rest from being created