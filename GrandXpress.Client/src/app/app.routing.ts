import { Routes } from "@angular/router";
import { TransactionMaintenanceComponent } from "./transaction-maintenance/transaction-maintenance.component";
import { TransactionDetailsComponent } from "./transaction-details/transaction-details.component";

export const appRoutes : Routes = [
    { path: "maintenance", component: TransactionMaintenanceComponent},
    {path:"details", component: TransactionDetailsComponent},
 
]