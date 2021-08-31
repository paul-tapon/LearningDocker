import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable, of, throwError } from 'rxjs';
import { catchError, filter, map, switchMap, take, tap } from 'rxjs/operators';
import { TicketType } from './types/ticket-type'
import { Ticket } from './types/ticket';
import { CreateTicketCommand } from './types/create-ticket-command';
import { environment } from 'src/environments/environment'
import { BuyTicketModel } from './types/buyTicketModel';
import { SimulateTravelResult } from './types/simulate-travel-result';

@Injectable({
    providedIn: 'root'
})
export class TicketService
{
    private _ticketTypes:BehaviorSubject<TicketType[] | null> = new BehaviorSubject(null);

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(private _httpClient: HttpClient)
    {

    }

    get ticketTypes$(): Observable<TicketType[]>
    {
        return this._ticketTypes.asObservable();
    }

    getTicketById(id:number): Observable<any>
    {
        var apiUrl = environment.baseApiUrl+'/ticket/'+id;
        return this._httpClient.get<any>(apiUrl);
    }

    getTicketByNumber(ticketNumber:string): Observable<any>
    {
        var apiUrl = environment.baseApiUrl+'/ticket/'+'getByNumber?ticketNumber='+ticketNumber;
        return this._httpClient.get<any>(apiUrl);
    }

    getTicketTypes(): Observable<TicketType[]>
    {
        return this._httpClient.get<TicketType[]>(environment.baseApiUrl+'/tickettype').pipe(
            tap((ticketTypes) => {
                this._ticketTypes.next(ticketTypes);
            })
        );
    }

    buyTicket(buyTicketModel:BuyTicketModel): Observable<Ticket> {
        
        var postData:CreateTicketCommand =  
        { 
            seniorIdNumber:buyTicketModel.seniorIdNumber,
            pwdIdNumber:buyTicketModel.pwdIdNumber,
            idType:buyTicketModel.idType!=null ? buyTicketModel.idType.id : null,
            ticketType:buyTicketModel.ticketType.id
        };

        return this
                ._httpClient
                .post<Ticket>(environment.baseApiUrl+"/ticket", postData, this.httpOptions);
    }

    simulateTravel(ticketNumber:string): Observable<SimulateTravelResult>
    {
        var postData = {ticketNumber};
        return this
                ._httpClient
                .post<SimulateTravelResult>(environment.baseApiUrl+"/ticket/SimulateTravel", postData, this.httpOptions);
    }

    private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {
    
          console.error(error); 

          return of(result as T);
        };
    }
    
}