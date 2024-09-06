import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from './components/main/main.component';
import { LancamentoComponent } from './components/lancamentos/transaction.component';
import { RelatorioComponent } from './components/relatorios/relatorio.component';

export const DEFAULT_ROUTE = '/home';

const routes: Routes = [
  { path: '', redirectTo: DEFAULT_ROUTE, pathMatch: 'full' },
  { path: 'home', component: MainComponent },
  { path: 'lancamentos', component: LancamentoComponent },
  { path: 'relatorios', component: RelatorioComponent },
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
