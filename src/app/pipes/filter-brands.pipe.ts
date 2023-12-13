import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'filterBrands'
})
export class FilterBrandsPipe implements PipeTransform {

    transform(value: any, filterString?: any): any {
        if(value.length === 0 || filterString === '')
        {
            return value;
        }
        
        const categories = [];
        for(const category of value)
        {
            if(category['tenBrand'].toLowerCase().includes(filterString.toLowerCase()))
            {
                categories.push(category);
            }
        }
        return categories;
    }

}
