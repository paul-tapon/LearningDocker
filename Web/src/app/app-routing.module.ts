import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TicketListComponent } from './ticket/ticket-list/ticket-list.component';
import { TicketBuyComponent } from './ticket/ticket-buy/ticket-buy.component';
import { TicketConfirmationComponent } from './ticket/ticket-confirmation/ticket-confirmation.component';
import { TravelSimulationComponent } from './ticket/travel-simulation/travel-simulation.component';

import { TicketTypeResolver } from 'src/app/ticket/ticket-type-resolver';


const routes: Routes = [
  { 
    path: 'ticket-list', 
    component: TicketListComponent 
  },
  { 
    path: 'ticket-buy', 
    component: TicketBuyComponent,
    resolve : { ticketTypes:TicketTypeResolver }
  },
  {
    path: 'ticket-confirmation', 
    component: TicketConfirmationComponent 
  },
  {
    path: 'travel-simulation', 
    component: TravelSimulationComponent 
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
