# Part 02 — answers

---

## Reports

- What was the problem?

the 3 classes for csv, json and text export each had the same
`Export` method (load, validate, format, save) and identical load, validate and save 
steps. only `Format` differed. the order of the steps
was written three times, so any change to the order or to the validation
rule had to be made in three places, and it was easy to miss one

- What did you change?

 I added an abstract base class, `ReportExporter`. Its non-virtual `Export`
  method is the template method and is the only place where the steps and
  their order are written. `Load`, `Validate`, and `Save` are private and
  written once in the base class. `Format` is a `protected abstract` method.
  Each of the three exporters now contains only its own `Format`
  implementation. The report files are still produced with the same content
  as before

- Why did you choose that approach?

The problem has a fixed sequence of steps where only one step varies, which
  is exactly what Template Method is for. I used an abstract class instead of
  an interface because the shared steps and the step order are real
  implementation. With an interface, each exporter would have to repeat that
  code, which would bring the duplication back. An abstract class lets me write
  it once and inherit it. It also lets me control what can change: `Export`
  is not virtual, so subclasses can't reorder the steps, and the shared steps
  are private, so only `Format` is an extension point. Finally, the
  relationship is "a CSV exporter is a report exporter that shares behavior",
  not just "can do something", so inheriting from a base class fits better
  than implementing a contract

---

## Enrollment

- What was the problem?
- What did you change?
- Why did you choose that approach?
