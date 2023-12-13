import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Product } from 'src/app/models/Product.model';
import { ProductService } from 'src/app/services/product.service';

@Component({
    selector: 'app-load-products',
    templateUrl: './load-products.component.html',
    styleUrls: ['./load-products.component.scss']
})
export class LoadProductsComponent implements OnInit, OnChanges {
    products: Product[] = [];
    gridShow: boolean = true;
    @Input() priceValue: number;
    constructor(private productService: ProductService) { }


    ngOnInit(): void {
        this.getProducts();
    }

    getProducts() {
        this.productService.getProducts().subscribe({
            next: (products) => {
                this.products = products;
            },
            error: (error) => console.log(error)
            
        })
    }

    ShowProductByGrid() {
        this.gridShow = true;
    }

    ShowProductByRow() {
        this.gridShow = false;
    }


    SortProducts(event) {
        // console.log(event);
        // // Lấy phần tử select
        // const selectElement: HTMLSelectElement = event.target;

        // // Lấy thông tin về option được chọn
        // const selectedOption: HTMLOptionElement = selectElement.options[selectElement.selectedIndex];

        // Lấy value
        // const value = selectedOption.value;

        const selectTag = document.getElementById('mySelect') as HTMLSelectElement
        if (selectTag.value === 'increasing') 
        {
            this.IncreasingSort();
        }
        else if (selectTag.value === 'decreasing') 
        {
            this.DescreasingSort();
        }
        else if (selectTag.value === 'alphabet')
        {
            this.AlphabetSort();
        }
    }


    IncreasingSort() {
        this.products.sort((a, b) => {
            return a.giaSanPham - b.giaSanPham;
        });
    }


    DescreasingSort() {
        this.products.sort((a, b) => {
            return b.giaSanPham - a.giaSanPham;
        })
    }

    AlphabetSort() {
        this.products.sort((a, b) => {
            return a.tenSanPham.localeCompare(b.tenSanPham)
        })
    }
    
    filterByPrice(priceLevel) {
        let filteredProducts : Product[] = [];
        // Lọc dữ liệu từ mảng products và gán vào filteredProducts

        if(priceLevel === 0 )
        {
            this.getProducts();
            return;
        }
        if (priceLevel === 1) {
            filteredProducts = this.products.filter(product => product.giaSanPham < 5000000);
        } else if (priceLevel === 2) {
            filteredProducts = this.products.filter(product => product.giaSanPham >= 5000000 && product.giaSanPham <= 7000000);
        } else if (priceLevel === 3) {
            filteredProducts = this.products.filter(product => product.giaSanPham >= 7000000 && product.giaSanPham <= 10000000);
        } else if (priceLevel === 4) {
            filteredProducts = this.products.filter(product => product.giaSanPham > 10000000);
        } else {
            // Nếu không có mức giá nào được chọn, hiển thị tất cả sản phẩm
            filteredProducts = [...this.products];
        }
        this.products = filteredProducts
        console.log(this.products);
    }

    ngOnChanges(changes: SimpleChanges): void {
        this.filterByPrice(this.priceValue);
    }



}
