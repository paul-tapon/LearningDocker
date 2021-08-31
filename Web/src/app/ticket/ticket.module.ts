import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { TicketListComponent } from './ticket-list/ticket-list.component';
import { TicketBuyComponent } from './ticket-buy/ticket-buy.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSliderModule } from '@angular/material/slider';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatRippleModule } from '@angular/material/core';
import { MatSortModule } from '@angular/material/sort';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatTableModule } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { FormsModule } from '@angular/forms';
import { TicketConfirmationComponent } from './ticket-confirmation/ticket-confirmation.component';
import { ReactiveFormsModule } from '@angular/forms';
import { TextMaskModule } from 'angular2-text-mask';

@NgModule({
    declarations: [
        TicketListComponent,
        TicketBuyComponent,
        TicketConfirmationComponent
    ],
    imports :
    [
        MatSliderModule,BrowserAnimationsModule,MatButtonModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatSelectModule,
        ReactiveFormsModule,
        FormsModule,
        TextMaskModule
    ]
})
export class TicketModule
{
}