import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FaseSelecaoComponent } from './components/fase-selecao/fase-selecao.component';
import { ResultadoFinalComponent } from './components/resultado-final/resultado-final.component';

const routes: Routes = [
  { path: '', redirectTo: 'fase-selecao', pathMatch: 'full'},
  { path: 'fase-selecao', component: FaseSelecaoComponent  },
  { path: 'resultado-final/:id', component: ResultadoFinalComponent  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
