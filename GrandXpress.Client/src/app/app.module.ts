import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {RouterModule} from '@angular/router';
import {HttpClientInMemoryWebApiModule} from 'angular-in-memory-web-api';
import {HttpClientModule} from '@angular/common/http';

import { AppComponent } from './app.component';
import { TransactionMaintenanceComponent } from './transaction-maintenance/transaction-maintenance.component';
import { appRoutes } from './app.routing';
import { TransactionDetailsComponent } from './transaction-details/transaction-details.component';
import { TransServiceService } from './services/trans-service.service';

import { InMemTransService } from './services/InMemoryDataService';
import { delay } from 'rxjs/operators';
import { MessageService } from './services/message.service';
import { HttpClient } from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent,
    TransactionMaintenanceComponent,
    TransactionDetailsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    HttpClientInMemoryWebApiModule.forRoot(InMemTransService, { dataEncapsulation: false }),
    RouterModule.forRoot(appRoutes)
  ],
  providers: [TransServiceService, MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
