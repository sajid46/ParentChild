import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ParentComponent } from './components/parent/parent.component';

import { RouterModule, Routes } from '@angular/router';

const appRouter: Routes = [
{ path: 'Home', component : ParentComponent }
];



@NgModule({
  declarations: [
    AppComponent,
    ParentComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule.forRoot
    (appRouter)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
