import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  transform(value: any[], filterString:string,propName:string): any[] {
    const resArray=[];
    if(value.length===0 || filterString==='' || propName==='')
    {
     return value;
    }
    for(const item of value)
    {
      if(item[propName]===filterString)
      {
       resArray.push(item);
      }
    }

    return resArray;
  }

}
