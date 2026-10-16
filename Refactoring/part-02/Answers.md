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

To enroll one student, `Program.cs` created four services itself
  (`PaymentGateway`, `SeatInventory`, `InvoiceGenerator`, `EmailService`)
  and called them one by one in the right order. It also had to pass the
  invoice id returned by `InvoiceGenerator` into the confirmation email.
  The caller therefore needed to know which services exist, the order they
  must run in, and how data flows between them. Any other place that
  enrolled a student would have to repeat all of that

- What did you change?

I added `EnrollmentFacade` in its own file in the Enrollment namespace.
  It creates the four services as private readonly fields and exposes one
  public method, `Enroll(studentId, courseId, amount)`. Inside it, the
  facade charges the student, reserves the seat, creates the invoice,
  keeps the returned invoice id, and sends the confirmation email.
  `Program.cs` now creates the facade and makes a single `Enroll` call.
  `Services.cs` was not changed, and the console output is the same as
  before

- Why did you choose that approach?

The Facade pattern fits because the problem is a group of classes that
  always work together and are awkward to use directly. The facade gives
  the caller one simple entry point without changing the services. The
  caller no longer needs to know that the four services exist, what order
  they run in, or that the invoice id has to be passed to the email step.
  If a step is added, removed, or reordered, only `EnrollmentFacade`
  changes, not every caller. I kept the facade free of extra logic
  (no validation or error handling), because its job is only to
  coordinate, and anything more would change the behavior the task asks
  me to keep