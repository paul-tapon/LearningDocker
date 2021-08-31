import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import { TicketService } from 'src/app/ticket/ticket.service'
import { Ticket } from 'src/app/ticket/types/ticket'


@Component({
  selector: 'app-ticket-confirmation',
  templateUrl: './ticket-confirmation.component.html',
  styleUrls: ['./ticket-confirmation.component.css']
})
export class TicketConfirmationComponent implements OnInit 
{

  ticket:Ticket = null;

  constructor(private _router: Router,private _ticketService:TicketService) 
  {
  }

  ngOnInit(): void {
    history.state.ticketId
    this._ticketService.getTicketById(history.state.ticketId).subscribe(t=>
      {
        console.log(t);
        this.ticket = t;
      }
    );
  }

}
