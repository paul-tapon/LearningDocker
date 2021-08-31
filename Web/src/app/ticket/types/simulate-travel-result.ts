export interface SimulateTravelResult
{
    ticketId:number;
    ticketNumber:string;
    newBalance:number;
    previousBalance:number;
    ticketTypeName:string;
    lastUsedDate:Date;
}