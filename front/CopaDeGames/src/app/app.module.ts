import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CampeonatoComponent } from './components/campeonato/campeonato.component';
import { CampeoesComponent } from './components/campeoes/campeoes.component';
import { FaseSelecaoComponent } from './components/fase-selecao/fase-selecao.component';
import { ResultadoFinalComponent } from './components/resultado-final/resultado-final.component';

@NgModule({
  declarations: [
    AppComponent,
    CampeonatoComponent,
    CampeoesComponent,
    FaseSelecaoComponent,
    ResultadoFinalComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
