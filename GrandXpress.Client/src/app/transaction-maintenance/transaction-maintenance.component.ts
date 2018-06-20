import { Component, OnInit } from '@angular/core';
import { TransServiceService } from '../services/trans-service.service';
import { Transaction } from '../models/transaction';

@Component({
  selector: 'app-transaction-maintenance',
  templateUrl: './transaction-maintenance.component.html',
  styleUrls: ['./transaction-maintenance.component.css']
})
export class TransactionMaintenanceComponent implements OnInit {

  transactions :Transaction [];
  constructor(private _sevice: TransServiceService ) { }

  ngOnInit() {
    this.getTransactions();
  }

  getTransactions(): void{
    debugger;
    this._sevice.getTransactions()
    .subscribe(trans=>this.transactions = trans);
  }

}
