import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable, of, throwError } from 'rxjs';
import { catchError, filter, map, switchMap, take, tap } from 'rxjs/operators';
import { TicketType } from './types/ticket-type'
import { Ticket } from './types/ticket';
import { CreateTicketCommand } from './types/create-ticket-command';
import { environment } from 'src/environments/environment'

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
        console.log(apiUrl);
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

    buyRegularTicket(): Observable<Ticket> {
        let postData:CreateTicketCommand =  { idNumber:"",idType:"",ticketType:1};
        return this
                ._httpClient
                .post<Ticket>(environment.baseApiUrl+"/ticket", postData, this.httpOptions);
    }


    private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {
    
          console.error(error); 

          return of(result as T);
        };
    }
}