export interface Ticket
{
    ticketId:number;
    ticketNumber:string;
    balance:number;
    ticketTypeName:string;
    validUntil:Date;
    lastDateUsed:Date;
}