   M S B A M L   `   `   `  ����E  AProjektWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:UpravljanjeProjektimaUpravljanjeProjektima  5      K GCsla, Version=3.6.0.0, Culture=neutral, PublicKeyToken=93be5fdc093e4c301$clr-namespace:Csla.Wpf;assembly=CslaCsla.Wpf 5      R NProjekt.Bll, Version=1.0.0.0, Culture=neutral, PublicKeyToken=30ab9c75db8e6db1R8clr-namespace:UpravljanjeProjektima;assembly=Projekt.BllUpravljanjeProjektima 5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      '    !UpravljanjeProjektima.ProjektEdit   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      5local#clr-namespace:UpravljanjeProjektima     5      5csla$clr-namespace:Csla.Wpf;assembly=Csla     5      Iproj8clr-namespace:UpravljanjeProjektima;assembly=Projekt.Bll     5      9system&clr-namespace:System;assembly=mscorlib     5        � 	Resources  5      /   )UpravljanjeProjektima.VisibilityConverter   VisibilityConverter   Csla.Wpf.IdentityConverter  IdentityConverter  Csla.Wpf.CslaDataProvider  	UlogeList   
ObjectType%  UpravljanjeProjektima.UlogaList   FactoryMethod   IsAsynchronous  Projekt#  UpravljanjeProjektima.Projekt,  &System.Windows.Data.DataSourceProvider   IsInitialLoadEnabled   ManageObjectLifetime  Csla.Wpf.ObjectStatus  ProjektStatus � DataContext��%  &	        &	      &	 &     &	 e     &	 �     7    5	   
   6$     5
   
   6!     5   
   "  5      $	 Get��5       . 5        5   
   -   5        "  5      $	 Get��5       .   .   . 5        5   
   8   5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Open��5      5      .��5      � -   5        $��MainGrid��5      $��0 0 20 0q�6S    6   �� 	 �� Source#	 [   5   
     
lbTemplate
 �� Orientation  
LinkButton �� Path �� DisplayMemberPath �� SelectedValuePath �� SelectedValue �� BindsDirectlyToSource  lbroTemplate1	   +UpravljanjeProjektima.ListTemplateConverter  ListTemplateConverter 	  TrueTemplate 	  FalseTemplate��%�  &	       7  7  7  &	 �    7  7  &	 z    7  7  �� 5       .R�5!      � .+�5"      �� $
 
Horizontal=�6!   .+�5#      �� 8��  $��0q�5$      $	��200��6    $��ApplicationCommands.Open��5%      
����  ���5&      �� $ IdOsobe���5'      �� $ PunoImeOsobe�6;   �� 5(      $	��150��6J   ��6$   �� $ DatDodjeleUloge�6J   �� 5)      $ Value��5+      $	 Key��5,      $	��150��5.      ��5*      �� 8	   5-      �� $ IdUloge�5.      �� 5/      $
��Left=�6   $ ��ApplicationCommands.Delete��50      $��Obriši��53      ��51      �� 8	  $ CommandManager� . ��52      �� 53      54      55      56      �� 57      .R�58      � .+�59      �� $
 
Horizontal=�6!   .+�5:      �� 8��  $��0q�5;      $	��200��6    $��ApplicationCommands.Open��5<      
����  ���5=      �� $ IdOsobe���5>      �� $ PunoImeOsobe�6;   �� 5?      $	��100��6J   ��6$   �� $ DatDodjeleUloge�6J   �� 5@      $ Value��5B      $	 Key��5C      $	��150��5E      {�.  ��5A      �� 8	   5D      �� $ IdUloge�5F      5G      5H      5I      	  5J      8   8  5L   $   5M       � RowDefinitions 5N   
   �� 5O      $
��Auto �6   �� 5P      $��* �6   .+�5R   
   �� $
 
Horizontal=�6   $��0��6.   .+�5S      ��  	 HeaderTextBlock#��[	 6   	Projekt6J   
  Csla.Wpf.BusyAnimation
  5T      -   5        $
��Busy��5T   !   $��20��6-   $��20��69   $��5q�6D    
  	IsRunning 5U      �� #	 [ $ IsBusy� . 5V      �� 5W   
   $
��Auto=�6   $��1��6:   .��5X      �� .+�5Y      �� 	Šifra:6$   � 5[       � ColumnDefinitions 5\      �� 5]      $��* �6+   �� 5^      $
��Auto �6+   .+�5`      �� -   5        $��SifraTextBox��5`      ��62   �� *SifProjekta+ �� 	Converter# [ 6     Csla.Wpf.PropertyStatus  5a         Property$ SifProjekta��6=   $��1��6T      Source 6*   ��    Target 5b       ��  �� ElementName$ SifraTextBox��5c      �� 5d      Naziv:6$   � 5e       5f      �� 5g      $��* �6+   �� 5h      $
��Auto �6+   .+�5j      �� -   5        $��NameTextBox��5j      $��0��61   ��5k      �� *NazProjekta+# [   5l      $ NazProjekta��6=   $��1��6T    6*   ��  5m       �� $ NameTextBox��5n      �� 5o      	Započet:6&   � 5p       5q      �� 5r      $��* �6+   �� 5s      $
��Auto �6+   .+�5u      �� -   5        $��StartedTextBox��5u      ��64   �� *
DatPocetka+# [ 6�     5v      $ 
DatPocetka��6=   $��1��6S    6*   ��  5w       �� $ StartedTextBox��5x      �� 5y      	Završen:6&   � 5z       5{      �� 5|      $��* �6+   �� 5}      $
��Auto �6+   .+�5      �� -   5        $��EndedTextBox��5      ��62   �� *DatZavrsetka+# [ 6�     5�      $ DatZavrsetka��6=   $��1��6U    6*   ��  5�       �� $ EndedTextBox��5�      �� 5�      Opis:6#   � 5�       5�      �� 5�      $��* �6+   �� 5�      $
��Auto �6+   .+�5�      �� -	   5        $��DescriptionTextBox��5�      $��0��5�       �� TextWrapping$
 Wrap=�5�      " �� VerticalScrollBarVisibility$
 Auto=�5�      $	��100��5�      ��5�      �� *OpisProjekta+# [ 5�        5�      $ OpisProjekta��6=   $��1��6U    6*   ��  5�       �� $ DescriptionTextBox��5�      �� 5�      Sudionici projekta:61   �� 5�      ��6   �� *SudioniciProjekta+��5�      �� #	 [ $ CanEditObject�# [ �� 5�      $
 
Horizontal=�6   y�5�      �� #	 [ $ CanEditObject�# [  .+�5�      �� $��ApplicationCommands.Save��6   $
��Left=�5�       �� 	IsDefault . ��5�      �� #	 [ $ CommandManager� . .��5�   =   Spremi6E   �� 5�      $��ApplicationCommands.Undo��6   $
��Left=�5�       �� IsCancel . ��5�      �� #	 [ $ CommandManager� . .��5�   <   
Odustani6F   �� 5�      -
   5        $
��Left=�5�      {�5�      �� #	 [ $ CanEditObject�.��5�   ,   Dodaj sudionika6=   5�      5�      5�      5�      5�      