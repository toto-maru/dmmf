namespace OrdeTaking.Domain

// types follow

// # Value Objects
// product code related
type WidgetCode = WidgetCode of string
// constraint: starting with "W" then 4 digits

type GizmoCode = GizmoCode of string
// constraint: starting with "G" then 4 digits

type ProductCode =
    | Widget of WidgetCode
    | Gizmo of GizmoCode

// order quantity related

type UnitQuantity = UnitQuantity of int
type KilogramQuantity = KilogramQuantity of decimal

type OrderQuantity =
    | Unit of UnitQuantity
    | Kilos of KilogramQuantity

// Entities

type OrderId = Undefined
type OrderLineId = Undefined
type CustomerId = Undefined

type CustomerInfo = Undefined
type ShippingAddress = Undefined
type BillingAddress = Undefined
type Price = Undefined
type BillingAmount = Undefined

type Order =
    { Id: OrderId
      CustomerId: CustomerId
      ShippingAddress: ShippingAddress
      BillingAddress: BillingAddress
      OrderLines: OrderLine list
      AmountToBill: BillingAmount }

and OrderLine =
    { Id: OrderLineId
      OrderId: OrderId
      ProductCode: ProductCode
      OrderQuantity: OrderQuantity
      Price: Price }

type CheckNumber = CheckNumber of int
type CardNumber = CardNumber of int

type CardType =
    | Visa
    | MasterCard

type CreditCardInfo =
    { CardType: CardType
      CardNumber: CardNumber }

type PaymentMethod =
    | Cash
    | Check of CheckNumber
    | Card of CreditCardInfo

type PaymentAmount = PaymentAmount of decimal

type Currency =
    | EUR
    | USD

type Payment =
    { Amount: PaymentAmount
      Currency: Currency
      Method: PaymentMethod }


type PersonalName =
    { FirstName: string
      LastName: string
      MiddleInitial: string option }

type ContactId = ContactId of int
type PhoneNumber = PhoneNumber of string
type EmailAddress = EmailAddress of string

[<CustomEquality; NoComparison>]
type Contact =
    { ContactId: ContactId
      PhoneNumber: PhoneNumber
      EmailAddress: EmailAddress }

    override this.Equals(obj: obj) =
        match obj with
        | :? Contact as c -> this.ContactId = c.ContactId
        | _ -> false

    override this.GetHashCode() = hash this.ContactId
