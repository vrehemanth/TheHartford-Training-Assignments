import { Routes } from '@angular/router';
import { First } from './components/first/first';
import { Second } from './components/second/second';
import { Home } from './components/home/home';
// import { ChildA } from './components/first/child-a/child-a';
// import { ChildB } from './components/first/child-b/child-b';

export const routes: Routes = [
    { 
        path: 'first-component', component: First,
        children:[
            { path: '', redirectTo: 'child-a', pathMatch: 'full' }, 
            {
                path: 'child-a',
                loadComponent:()=>
                    import('./components/first/child-a/child-a').then(m=>m.ChildA),
                
            },
            {
                path:'child-b',
                loadComponent:()=>
                    import('./components/first/child-b/child-b').then(m=>m.ChildB),
            },
        ],
    },
    { path: 'second-component', component: Second }, 
    { path: 'home', component: Home }
];
