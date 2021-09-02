import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { TicketListComponent } from './ticket-list/ticket-list.component';
import { TicketBuyComponent } from './ticket-buy/ticket-buy.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { FormsModule } from '@angular/forms';
import { TicketConfirmationComponent } from './ticket-confirmation/ticket-confirmation.component';
import { ReactiveFormsModule } from '@angular/forms';
import { TextMaskModule } from 'angular2-text-mask';
import { TravelSimulationComponent } from './travel-simulation/travel-simulation.component';

import { MatNativeDateModule } from '@angular/material/core';
@NgModule({
    declarations: [
        TicketListComponent,
        TicketBuyComponent,
        TicketConfirmationComponent,
        TravelSimulationComponent
    ],
    imports :
    [
        MatDatepickerModule,BrowserAnimationsModule,MatButtonModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatSelectModule,
        ReactiveFormsModule,
        FormsModule,
        TextMaskModule,
        MatNativeDateModule
    ]
})
export class TicketModule
{
}