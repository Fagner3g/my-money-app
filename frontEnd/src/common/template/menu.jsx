import React from 'react'
import MenuItem from './menuItem'
import MenuTree from './menuTree'

export default () => (
    <ul className='sidebar-menu' data-widget="tree">
        <MenuItem path='#' label='Deshboard' icon='dashboard' />
        <MenuTree label='Cadastro' icon='edit'>
            <MenuItem path='#billingCycles' label='Ciclos de Pagamentos' icon='usd' />
        </MenuTree>
    </ul>
)