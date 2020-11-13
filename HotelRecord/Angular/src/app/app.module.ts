import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { Interpolation } from '@angular/compiler';
import {HttpClientModule }  from '@angular/common/http';
import { from } from 'rxjs';
import {FormsModule} from '@angular/forms'

import { HotelsComponent } from './hotels/hotels.component';
import { HotelListComponent } from './hotels/hotel-list/hotel-list.component';
import { HotelComponent } from './hotels/hotel/hotel.component';
import { HotelService } from './shared/hotel.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    HotelsComponent,
    HotelListComponent,
    HotelComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers:[HotelService],
  bootstrap: [AppComponent]
})
export class AppModule { }
