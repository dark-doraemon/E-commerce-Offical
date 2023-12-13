import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../models/Product.model';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class ProductService {

    constructor(private http : HttpClient) { }

    getProducts()
    {
        return this.http.get<Product[]>(environment.baseApiUrl + 'products');
    }
}
