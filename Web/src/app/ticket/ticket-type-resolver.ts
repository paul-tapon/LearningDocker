import { Injectable } from '@angular/core';
import { TicketType } from 'src/app/ticket/types/ticket-type'
import { TicketService } from 'src/app/ticket/ticket.service'
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TicketTypeResolver {


    constructor(private _ticketService: TicketService)
    {
    }


    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<TicketType[]>
    {
        return this._ticketService.getTicketTypes();
    }
}
