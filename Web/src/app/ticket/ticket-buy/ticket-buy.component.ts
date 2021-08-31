import { AfterViewInit, ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { debounceTime, map, switchMap, takeUntil } from 'rxjs/operators';
import { merge, Observable, Subject } from 'rxjs';
import { TicketType } from 'src/app/ticket/types/ticket-type'
import { TicketService } from 'src/app/ticket/ticket.service'
import { IdType } from 'src/app/ticket/types/IdType'

import {Router} from '@angular/router';
import { analyzeFile } from '@angular/compiler';


@Component({
  selector: 'app-ticket-buy',
  templateUrl: './ticket-buy.component.html',
  styleUrls: ['./ticket-buy.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TicketBuyComponent implements OnInit,AfterViewInit, OnDestroy {

  ticketBuyForm: FormGroup;

  idTypes:IdType[] = [ {id:1,name:"Senior Citizen"},{id:2,name:"PWD"} ];

  ticketTypes : TicketType[];
  selectedTicketType : TicketType =null;

  datemask = [/\d/, /\d/, '/', /\d/, /\d/, '/', /\d/, /\d/, /\d/, /\d/];

  private _unsubscribeAll: Subject<any> = new Subject<any>();


  constructor(
    private _ticketService: TicketService,
    private _changeDetectorRef: ChangeDetectorRef,
    private _router: Router,
    private _formBuilder: FormBuilder) 
  {

  }

  ngOnInit(): void 
  {
    // Get the brands
    this._ticketService.ticketTypes$
    .pipe(takeUntil(this._unsubscribeAll))
    .subscribe((ticketTypes: TicketType[]) => {

        // Update the brands
        this.ticketTypes = ticketTypes;

        // Mark for check
        this._changeDetectorRef.markForCheck();
    });

    this.ticketBuyForm = this._formBuilder.group({
      ticketType : new FormControl('',Validators.required),
      idType : new FormControl('')
    })
  }

  ngAfterViewInit(): void
  {
  }

  ngOnDestroy(): void
  {
  }

  onTicketTypeSelectChange(event,ticketType:TicketType)
  {
   
    if(event.isUserInput) {
      console.log(ticketType);

      this.selectedTicketType = ticketType;
      this._changeDetectorRef.markForCheck();
          //this.ticketBuyForm.controls['ticketType'].setErrors({'pattern':true});
      if(ticketType.id==2)
      {
        this.ticketBuyForm.controls['idType'].setValidators([Validators.required]);

      }
      else
      {
        this.ticketBuyForm.controls['idType'].setErrors(null);
        this.ticketBuyForm.controls['idType'].removeValidators([Validators.required]);
      }

      this.ticketBuyForm.updateValueAndValidity();
    }



  }

  onIdTypeSelectChange(event,ticketType:TicketType)
  {
   
    if(event.isUserInput) {
    }
  }

  proceedButtonClicked(){
    this
    ._ticketService
    .buyRegularTicket()
    .subscribe
    (
      c=> this._router.navigateByUrl("/ticket-confirmation",{ state : {  ticketId: c }})
    );
  }
  
  getErrorTicketType() {
    return this.ticketBuyForm.get('ticketType').hasError('required') ? 'Ticket Type is required' : '';
  }

  getErrorIdType() {
    return this.ticketBuyForm.get('idType').hasError('required') ? 'ID Type is required' : '';
  }

}
