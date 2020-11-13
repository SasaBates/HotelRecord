import { Component, OnInit } from '@angular/core';
import { HotelService } from 'src/app/shared/hotel.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { HotelChain } from 'src/app/shared/hotel-chain.model';


@Component({
  selector: 'app-hotel',
  templateUrl: './hotel.component.html',
  styleUrls: ['./hotel.component.css']
})
export class HotelComponent implements OnInit {

  hotelChains : HotelChain[];
  constructor(public hotelService : HotelService,
    public toastr : ToastrService) { }

  ngOnInit() {
    this.resetForm();
    return this.hotelService.getHotelsChain()
    .subscribe(data => {
      this.hotelChains = data})
  }

 resetForm(form? : NgForm){
   if (form = null)
   form.resetForm();
   this.hotelService.formData = {
     hotelId : null,
     name :'',
     openingYear :null,
     numberOfEmployees :null,
     numberOfRooms :null,
     hotelChainId : null,
   }
 }
 onSubmit(form : NgForm){
   if(form.value.hotelId == null)
this.insertRecord(form);
else
this.UpdateRecord(form);
 }

 insertRecord(form : NgForm){
this.hotelService.postHotel(form.value).subscribe(res => {
  this.toastr.info('Inserted successfoly','Hotel Record');
  this.resetForm(form);
  this.hotelService.getHotels();
   });
 }
 UpdateRecord(form : NgForm){
   this.hotelService.putHotel(form.value).subscribe(res => {    
    this.toastr.success(' Update successfoly','Hotel Record');
    this.resetForm(form);
     });
 }
 deleteChain(hotelChainId : number){

  if(confirm('Are you sure to delete this hotel chain')){
    this.hotelService.deleteHotelChain(hotelChainId).subscribe(res=>{
      this.toastr.warning('Deleted successfoly','Hotel Record');
    });
  }
 }

}
