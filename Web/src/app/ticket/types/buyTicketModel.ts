import { IdType } from "./IdType";
import { TicketType } from "./ticket-type";

export interface BuyTicketModel
{
    idType:IdType;
    seniorIdNumber:string;
    pwdIdNumber:string;
    ticketType:TicketType;
}