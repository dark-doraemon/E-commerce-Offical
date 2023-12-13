import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductViewComponent } from './components/productView/productview.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { HomeComponent } from './components/header/home/home.component';
import { ContactComponent } from './components/header/contact/contact.component';

const routes: Routes = [
    {path : '',component : HomeComponent},

    {path : 'home',component : HomeComponent},

    {path : 'productView', component: ProductViewComponent},
    {path : 'contact',component : ContactComponent},
    {path : '**',component : NotFoundComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
