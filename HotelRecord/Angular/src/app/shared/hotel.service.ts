import { Injectable } from '@angular/core';
import { Hotel } from './hotel.model';
import { NgForm } from '@angular/forms';
import{ HttpClient } from '@angular/common/http'
import { HotelChain } from './hotel-chain.model';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class HotelService {

  formData: Hotel;
  URL = "https://localhost:44394/api/";

  constructor(private http : HttpClient) { }

  postHotel(formData : Hotel){
    return this.http.post(this.URL + 'Hotel', formData)
  }

  getHotels(){
    return this.http.get<Hotel[]>(this.URL + 'Hotel')
  }

  putHotel(formData : Hotel){
    return this.http.put(this.URL + 'Hotel', formData)
  }

  deleteHotel(id : number){
    return this.http.delete(this.URL + 'Hotel/' + id);
  }
  
  getHotelsChain(){
    return this.http.get<HotelChain[]>(this.URL + 'Chain')
  }

  deleteHotelChain(hotelChainId){
    return this.http.delete(this.URL + 'Chain/' + hotelChainId);
  }
}


