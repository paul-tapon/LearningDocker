import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
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
        return this._httpClient
                    .get<any>(apiUrl)
                    .pipe(
                        catchError(error => {
                            
                            if (error.error instanceof ErrorEvent) {
                                return throwError(error);
                            } else {
                                var httpError:HttpErrorResponse =  error as HttpErrorResponse;
                                if(httpError != null)
                                {
                                    if(httpError.status == 404){
                                        return of(null);
                                    }
                                }
                            }
    
                            return throwError(error);
                        })
                    );
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

    simulateTravel(ticketNumber:string,travelDate:Date): Observable<SimulateTravelResult>
    {
        var postData = {ticketNumber,travelDate : this.formatDate(travelDate)};
        return this
                ._httpClient
                .post<any>(environment.baseApiUrl+"/ticket/SimulateTravel", postData, this.httpOptions);
    }

    private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {
    
          console.error(error); 

          return of(result as T);
        };
    }

    private formatDate(date:Date) : string{
      
        var day = ('0' + date.getDate()).slice(-2);
        var month = ('0' + (date.getMonth() + 1)).slice(-2);
        var year = date.getFullYear();
      
        return year + '-' + month + '-' + day;
    }

    private getServerErrorMessage(error: HttpErrorResponse): string {
        switch (error.status) {
            case 404: {
                return `Not Found: ${error.message}`;
            }
            case 403: {
                return `Access Denied: ${error.message}`;
            }
            case 500: {
                return `Internal Server Error: ${error.message}`;
            }
            default: {
                return `Unknown Server Error: ${error.message}`;
            }

        }
    }
    
}