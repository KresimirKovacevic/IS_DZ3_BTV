   M S B A M L   `   `   `  ����E  AProjektWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:UpravljanjeProjektimaUpravljanjeProjektima  5      K GCsla, Version=3.6.0.0, Culture=neutral, PublicKeyToken=93be5fdc093e4c301$clr-namespace:Csla.Wpf;assembly=CslaCsla.Wpf 5      R NProjekt.Bll, Version=1.0.0.0, Culture=neutral, PublicKeyToken=30ab9c75db8e6db1^>clr-namespace:UpravljanjeProjektima.Admin;assembly=Projekt.BllUpravljanjeProjektima.Admin 5      %    UpravljanjeProjektima.UlogeEdit   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      5local#clr-namespace:UpravljanjeProjektima     5      5csla$clr-namespace:Csla.Wpf;assembly=Csla     5      Oproj>clr-namespace:UpravljanjeProjektima.Admin;assembly=Projekt.Bll     5        � 	Resources  5        Csla.Wpf.CslaDataProvider   	UlogeList   
ObjectType'  !UpravljanjeProjektima.Admin.Uloge   FactoryMethod   IsAsynchronous   ManageObjectLifetime��%^   &	          5   
   -   5        "  5	      $	 Get��5
       .   . 5      5      .��5      �� $
��Auto=�6   $��1��66   .��5   
   � -   5        $��MainGrid��5       � DataContext 6   ��  �� Source# [    5   
     
lbTemplate �� Orientation ��Name	 �� Path  Csla.Wpf.PropertyStatus
   Property   Source   Target �� ElementName �� BindsDirectlyToSource��%�  &	       7   �� 5      .R�5      � .+�5      �� $ 
Horizontal=�6!   .+�5      �� Id:6)   �� 5      $ 	IdTextBox��6"   $	��100��5      ��5   5   �� $	 IdUloge�5        5      $
 IdUloge��6A   $��1��6T    6.   ��  5   "   �� $ 	IdTextBox���� 5      Naziv:6,   �� 5      $ NameTextBox��6"   $	��250��5       ��5      �� $	 NazUloge�5         5!      $
 NazUloge��6A   $��1��6U    6.   ��  5"   "   �� $ NameTextBox���� 5#      $ ��ApplicationCommands.Delete��5$      $
��Left=�5'      ��5%      �� ��5&      �� 8   $	 CommandManager� . .��5'   *   	Obriši62   5(      5)      5*      5+      .+�5-   
   �� .+�5.      �� $ 
Horizontal=�6   .+�5/      �� Uloge:6$     Csla.Wpf.BusyAnimation  50      -   5        $
��Busy��50   %   $��20��61   $��20��6=   $��5q�6H      	IsRunning 51      �� # [  $	 IsBusy� . 52      �� 53      -   5        $��RolesListBox��53      #��[ 55      ��54      �� 55      �� 56      $ 
Horizontal=�6   .+�57      �� $��ApplicationCommands.Save��58      $
��Left=�5:       �� 	IsDefault . ��59      �� # [  $	 CommandManager� . .��5:   ;   Spremi6C   �� 5;      $��ApplicationCommands.Undo��5<      $
��Left=�5>       �� IsCancel . ��5=      �� # [  $	 CommandManager� . .��5>   :   
Odustani6D   �� 5?      -   5        $��AddItemButton��5?      $��ApplicationCommands.New��5@      $
��Left=�5B       . ��5A      �� # [  $	 CommandManager� . .��5B   :   Dodaj ulogu6G   5C      5D      5E      5G      5I      