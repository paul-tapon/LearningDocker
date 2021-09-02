import { AfterViewInit, ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { debounceTime, map, switchMap, takeUntil } from 'rxjs/operators';
import { merge, Observable, Subject } from 'rxjs';
import { TicketType } from 'src/app/ticket/types/ticket-type'
import { TicketService } from 'src/app/ticket/ticket.service'
import { IdType } from 'src/app/ticket/types/IdType'

import {Router} from '@angular/router';
import { analyzeFile } from '@angular/compiler';
import { BuyTicketModel } from '../types/buyTicketModel';


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
  selectedIdType : IdType = null;

  seniorIdFormat = [/\d/, /\d/, '-', /\d/, /\d/,/\d/,/\d/, '-', /\d/, /\d/, /\d/, /\d/];
  pwdIdFormat = [/\d/, /\d/,  /\d/, /\d/, '-', /\d/, /\d/,/\d/,/\d/, '-', /\d/, /\d/, /\d/, /\d/];

  seniorIdFormatRegex = "^\\d{2}-\\d{4}-\\d{4}$";
  pwdIdFormatRegex = "^\\d{4}-\\d{4}-\\d{4}$";

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

        console.log(this._changeDetectorRef);
        // Mark for check
        this._changeDetectorRef.markForCheck();
    });

    this.ticketBuyForm = this._formBuilder.group({
      ticketType : new FormControl('',Validators.required),
      idType : new FormControl(''),
      seniorCitizenId : new FormControl('',Validators.pattern(this.seniorIdFormatRegex)),
      pwdId : new FormControl('',Validators.pattern(this.pwdIdFormatRegex))
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

  onIdTypeSelectChange(event,idType:IdType)
  {
    if(event.isUserInput)
    {
      this.selectedIdType = idType;
      console.log(idType);

      if(idType.id==1) //Senior
      {
        this.ticketBuyForm.controls['seniorCitizenId'].setValidators([Validators.required,Validators.pattern(this.seniorIdFormatRegex)]);

        this.ticketBuyForm.controls['pwdId'].setValue('');
        this.ticketBuyForm.controls['pwdId'].removeValidators([Validators.required,Validators.pattern(this.pwdIdFormatRegex)]);
        this.ticketBuyForm.controls['pwdId'].setErrors(null);

      }
      else
      {
        this.ticketBuyForm.controls['pwdId'].setValidators([Validators.required,Validators.pattern(this.pwdIdFormatRegex)]);

        this.ticketBuyForm.controls['seniorCitizenId'].setValue('');
        this.ticketBuyForm.controls['seniorCitizenId'].removeValidators([Validators.required,Validators.pattern(this.seniorIdFormatRegex)]);
        this.ticketBuyForm.controls['seniorCitizenId'].setErrors(null);

      }

      this.ticketBuyForm.updateValueAndValidity();
    }

  }

  proceedButtonClicked()
  {
    var buyTicketmodel:BuyTicketModel =  
    {
      idType : this.selectedIdType, 
      seniorIdNumber:this.ticketBuyForm.controls['seniorCitizenId'].value,
      pwdIdNumber:this.ticketBuyForm.controls['pwdId'].value,
      ticketType:this.selectedTicketType
    };
    this
    ._ticketService
    .buyTicket(buyTicketmodel)
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
