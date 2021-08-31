import { AfterViewInit, ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { merge, Observable, Subject } from 'rxjs';
import { Ticket } from 'src/app/ticket/types/ticket'
import { TicketService } from 'src/app/ticket/ticket.service'
import { IdType } from 'src/app/ticket/types/IdType'
import { Router } from '@angular/router';
import { SimulateTravelResult } from 'src/app/ticket/types/simulate-travel-result';



@Component({
  selector: 'app-travel-simulation',
  templateUrl: './travel-simulation.component.html',
  styleUrls: ['./travel-simulation.component.css']
})
export class TravelSimulationComponent implements OnInit {

  simulationFormGroup: FormGroup;

  idTypes:IdType[] = [ {id:1,name:"Senior Citizen"},{id:2,name:"PWD"} ];

  ticket:Ticket = null;
  notFound:boolean = null;
  simulateTravelResult:SimulateTravelResult = null;

  private _unsubscribeAll: Subject<any> = new Subject<any>();


  constructor(
    private _ticketService: TicketService,
    private _router: Router,
    private _formBuilder: FormBuilder) 
  {

  }

  ngOnInit(): void 
  {

    this.simulationFormGroup = this._formBuilder.group({
      ticketIdNumber : new FormControl('',[Validators.required,Validators.maxLength(12),Validators.minLength(7)])
    });

  }

  ngAfterViewInit(): void
  {
  }

  ngOnDestroy(): void
  {
  }

  showBalance(){
    
    this.simulateTravelResult=null;
    this._ticketService
      .getTicketByNumber(this.simulationFormGroup.controls['ticketIdNumber'].value)
      .subscribe(t=>{
        if(t==null)
        {
          this.notFound=true;
          this.ticket=null;
        }
        else
        {
          this.notFound=null;
          this.ticket=t;
        }
      });
  }

  proceedButtonClicked()
  {

    this.simulateTravelResult=null;
    this._ticketService
    .simulateTravel(this.simulationFormGroup.controls['ticketIdNumber'].value)
    .subscribe(r=>{
      this.simulateTravelResult=r;
    });

  }
  
  getErrorTicketNumber() {
    return this.simulationFormGroup.get('ticketIdNumber').hasError('required') ? 'Ticket number is required' : 
    this.simulationFormGroup.get('ticketIdNumber').hasError('minLength') ? 'Minimum length is 7 numbers' : '' ;
  }



}
