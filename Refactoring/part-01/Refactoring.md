# Part 01 — answers

---

## ShippingCostCalculator

- What was the problem?
The carriers were hard-coded inside the class using a switch statement. Adding a new carrier meant
editing ShippingCostCalculator itself, which violates the OCP (the class should be
open for extension but closed for modification).

- What did you change?
I created an ICarrier interface (with a Name and a CalculateCost method) and moved each carrier's
pricing into its own class (AramexCarrier, FedExCarrier, DhlCarrier). ShippingCostCalculator now
receives the list of carriers through its constructor and looks up the right one by name, so it no
longer knows anything about specific carriers. A new carrier is added by creating a new class that
implements ICarrier, without modifying ShippingCostCalculator.

---

## OrderProcessor

- What was the problem?
OrderProcessor created its own SqlOrderRepository and SmtpEmailSender inside the Process method
using new. This tightly coupled the high-level business logic to concrete low-level classes, which
violates the Dependency Inversion Principle. Changing the database or the email service meant
editing OrderProcessor itself, and the class couldn't be tested in isolation because every call
used the real implementations.

- What did you change?
I created two interfaces, IOrderRepository and IEmailSender, and made SqlOrderRepository and
SmtpEmailSender implement them. OrderProcessor now receives both interfaces through its
constructor and only uses them, so it no longer depends on any concrete
class. Program.cs creates the concrete classes and passes them in. The output is unchanged.


---

## Notifications

- What was the problem?
The notification classes used inheritance to combine independent choices (channel, urgent, and
scheduled). Each combination needed its own class (UrgentEmailNotification,
UrgentScheduledSmsNotification, and so on), so the number of classes grew with every new channel or
option. Some classes also duplicated logic instead of reusing it: the UrgentScheduled classes
re-implemented the email/SMS format and the [URGENT] prefix by hand. An urgent email isn't a special
kind of email, it is an email with a flag, so inheritance was the wrong tool. Adding a new channel
meant creating a whole new set of classes.

- What did you change?
I replaced the inheritance chain with composition. I created an INotificationChannel interface
with EmailChannel and SmsChannel implementations, which only handle how a message is delivered.
A single Notification class now holds a channel and two options (urgent and sendAt), adds the
[URGENT] prefix when needed, and passes the message to the channel. Any combination of channel,
urgent, and scheduled is built at runtime with no extra classes, and the output is the same as
before. A new channel is added by writing one new class that implements INotificationChannel.

---

## Proof

- New carrier file(s): UpsCarrier.cs
- New notification channel file(s): WhatsAppChannel.cs
- Existing classes left unchanged? (yes/no): yes (only Program.cs was edited, to wire them in)
