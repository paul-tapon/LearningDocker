import { AfterViewInit, ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { merge, Observable, of, Subject, throwError } from 'rxjs';
import { catchError, filter, map, switchMap, take, tap } from 'rxjs/operators';
import { Ticket } from 'src/app/ticket/types/ticket'
import { TicketService } from 'src/app/ticket/ticket.service'
import { IdType } from 'src/app/ticket/types/IdType'
import { Router } from '@angular/router';
import { SimulateTravelResult } from 'src/app/ticket/types/simulate-travel-result';
import { HttpErrorResponse } from '@angular/common/http';



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
  simulationErrors: any[] = null;


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
      ticketIdNumber : new FormControl('',[Validators.required,Validators.maxLength(12),Validators.minLength(7)]),
      travelDate : new FormControl('',Validators.required)
    });

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
    .simulateTravel(this.simulationFormGroup.controls['ticketIdNumber'].value,this.simulationFormGroup.controls['travelDate'].value)
    .pipe(
      catchError(error => {
          if (error.error instanceof ErrorEvent) {
              return throwError(error);
          } else {
              var httpError:HttpErrorResponse =  error as HttpErrorResponse;
              if(httpError != null)
              {
                  if(httpError.status == 400){
                    console.log("400");

                      return of(error.error);
                  }
              }
          }

          return throwError(error);
      })
    )
    .subscribe(r=>{
      

      var result:SimulateTravelResult = r as SimulateTravelResult;
      if(r.errors)
      {
        console.log(r.errors);

        var resultArray = Object.keys(r.errors).map(function(index){
          let err = r.errors[index];
          return err;
        });
        this.simulationErrors = resultArray;
      }
      else
      {
        this.simulateTravelResult=r;
      }


    });

  }
  
  getErrorTicketNumber() {
    return this.simulationFormGroup.get('ticketIdNumber').hasError('required') ? 'Ticket number is required' : 
    this.simulationFormGroup.get('ticketIdNumber').hasError('minLength') ? 'Minimum length is 7 numbers' : '' ;
  }

  disableTravel():boolean{
    return !this.simulationFormGroup.valid || this.notFound==true || this.ticket==null || (this.ticket!=null && this.ticket.validUntil<this.simulationFormGroup.controls['travelDate'].value);
  }


}
