import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { pipe } from 'rxjs';
import { Brand } from 'src/app/models/Brand.model';
import { Category } from 'src/app/models/LoaiSanPham.model';
import { BrandService } from 'src/app/services/brand.service';
import { CategoryService } from 'src/app/services/category.service';

@Component({
    selector: 'app-load-category',
    templateUrl: './loadcategory.component.html',
    styleUrls: ['./loadcategory.component.scss']
})
export class LoadcategoryComponent implements OnInit{

    categories : Category[];
    brands : Brand[];
    categoriesSearch : string = '';
    brandsSearch : string ='';
    @Output() priceFilter : EventEmitter<number> = new EventEmitter<number>();

    constructor(private categoryService : CategoryService, private brandServices : BrandService) {}

    

    ngOnInit(): void {
        this.getCategories();
        this.getBrands();
        this.priceFilter.emit(0);
    }

    getCategories()
    {
        this.categoryService.getCategories().subscribe({
            next : (categories) =>{
                this.categories = categories
            },
            error : error => console.log(error)
        })
    }

    getBrands()
    {
        this.brandServices.getBrands().subscribe({
            next : (brands) =>{
                this.brands = brands
            },
            error : error => console.log(error)

        })
    }


    SelectPrices(price : number)
    {
        this.priceFilter.emit(price);
    }

}
