import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Hotel } from 'src/app/shared/hotel.model';
import { HotelService } from 'src/app/shared/hotel.service';

@Component({
  selector: 'app-hotel-list',
  templateUrl: './hotel-list.component.html',
  styleUrls: ['./hotel-list.component.css']
})
export class HotelListComponent implements OnInit {

  hotels: Hotel[];
  constructor(private hotelService: HotelService,
    public toastr : ToastrService ){}

  ngOnInit(){
    return this.hotelService.getHotels()
    .subscribe(data => {
      this.hotels = data})
  }
  populateForm(hotel : Hotel){
    this.hotelService.formData = Object.assign({}, hotel);
  }

  delete(id : number){
    if(confirm('Are you sure to delete this hotel')){
    this.hotelService.deleteHotel(id).subscribe(res=>{
      this.hotelService.getHotels();
      this.toastr.warning('Deleted successfoly','Hotel Record');
    });
  }
  }

}
