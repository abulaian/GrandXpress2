import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MessageService } from './message.service';
import { Transaction } from '../models/transaction';
import { Observable } from 'rxjs/Observable';
import { catchError, tap } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';

@Injectable()
export class TransServiceService {
  
   public trans = [];

   private url = 'api/transactions';

  constructor(private httpClient: HttpClient,
  private messageServie: MessageService) { }

  getTransactions() : Observable<Transaction[]>{
    return this.httpClient.get<Transaction[]>(this.url)
    .pipe(
      tap(trans=>this.log('fetch transactions')),
      catchError(this.handleError( 'getTransactions', []))
    );
  }

  private log(message : string){
    this.messageServie.add("transaction Servie: " + message);
  }

  /**
 * Handle Http operation that failed.
 * Let the app continue.
 * @param operation - name of the operation that failed
 * @param result - optional value to return as the observable result
 */
private handleError<T> (operation = 'operation', result?: T) {
  return (error: any): Observable<T> => {

    // TODO: send the error to remote logging infrastructure
    console.error(error); // log to console instead

    // TODO: better job of transforming error for user consumption
    this.log(`${operation} failed: ${error.message}`);

    // Let the app keep running by returning an empty result.
    return of(result as T);
  };
}

}
