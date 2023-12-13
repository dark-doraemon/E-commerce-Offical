import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/header/home/home.component';
import { HeaderComponent } from './components/header/header.component';
import { ContactComponent } from './components/header/contact/contact.component';
import { LoadcategoryComponent } from './components/productView/load-categories/loadcategory.component';
import { LoadProductsComponent } from './components/productView/load-products/load-products.component';
import { FooterComponent } from './components/footer/footer.component';
import { MainComponent } from './components/main/main.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { ProductViewComponent } from './components/productView/productview.component';
import { SigninComponent } from './components/header/signin/signin.component';
import { SignupComponent } from './components/header/signup/signup.component';
import { ProductItemComponent } from './components/productView/load-products/product-item/product-item.component';
import { AdminComponent } from './components/admin/admin.component';
import { CartComponent } from './components/cart/cart.component';
import { HttpClientModule} from '@angular/common/http';
import { ProductItemRowComponent } from './components/productView/load-products/product-item-row/product-item-row.component'
import { FormsModule } from '@angular/forms';
import { FilterPipe } from './pipes/filterCategories.pipe';
import { FilterBrandsPipe } from './pipes/filter-brands.pipe';
@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        HeaderComponent,
        ContactComponent,
        LoadcategoryComponent,
        LoadProductsComponent,
        FooterComponent,
        MainComponent,
        NotFoundComponent,
        ProductViewComponent,
        SigninComponent,
        SignupComponent,
        ProductItemComponent,
        AdminComponent,
        CartComponent,
        ProductItemRowComponent,
        FilterPipe,
        FilterBrandsPipe,

    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        FormsModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
